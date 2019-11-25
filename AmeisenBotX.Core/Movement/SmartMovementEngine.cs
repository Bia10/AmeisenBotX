﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmeisenBotX.Core.Movement.Enums;
using AmeisenBotX.Core.Movement.Objects;
using AmeisenBotX.Core.Movement.Settings;
using AmeisenBotX.Pathfinding.Objects;
using static AmeisenBotX.Core.Movement.Objects.BasicVehicle;

namespace AmeisenBotX.Core.Movement
{
    public class SmartMovementEngine
    {
        public delegate List<Vector3> GeneratePathFunction(Vector3 start, Vector3 end);

        public SmartMovementEngine(GetPositionFunction getPositionFunction, GetRotationFunction getRotationFunction, MoveToPositionFunction moveToPositionFunction, GeneratePathFunction generatePathFunction, MovementSettings movementSettings)
        {
            State = MovementEngineState.None;
            GetPosition = getPositionFunction;
            GetRotation = getRotationFunction;
            MoveToPosition = moveToPositionFunction;
            GeneratePath = generatePathFunction;

            PlayerVehicle = new BasicVehicle(getPositionFunction, getRotationFunction, moveToPositionFunction, movementSettings.MaxSteering, movementSettings.MaxVelocity, movementSettings.MaxAcceleration);
        }

        public MovementEngineState State { get; private set; }

        public Queue<Vector3> CurrentPath { get; private set; }

        public Vector3 TargetPosition { get; private set; }

        public MoveToPositionFunction MoveToPosition { get; set; }

        public GetRotationFunction GetRotation { get; set; }

        public GetPositionFunction GetPosition { get; set; }

        public GeneratePathFunction GeneratePath { get; set; }

        public BasicVehicle PlayerVehicle { get; private set; }

        public MovementSettings MovementSettings { get; private set; }

        public void SetMove(Vector3 position)
            => SetNewState(MovementEngineState.Moving, position);

        public void SetFollow(Vector3 position)
            => SetNewState(MovementEngineState.Following, position);

        public void Execute()
        {
            if (CurrentPath.Count == 0)
            {
                List<Vector3> nodes = GeneratePath.Invoke(GetPosition.Invoke(), TargetPosition);

                if(nodes.Count == 0)
                {
                    // pathfinding was unsuccessful
                    return;
                }

                foreach (Vector3 node in nodes)
                {
                    CurrentPath.Enqueue(node);
                }
            }

            List<Vector3> forces = new List<Vector3>();
            Vector3 currentPosition = GetPosition.Invoke();
            Vector3 targetPosition = CurrentPath.Peek();
            double distanceToTargetPosition = currentPosition.GetDistance(targetPosition);

            if (distanceToTargetPosition < MovementSettings.WaypointCheckThreshold)
            {
                CurrentPath.Dequeue();
                targetPosition = CurrentPath.Peek();
            }

            Vector3 positionToGoTo = MoveAhead(targetPosition, 1.5);

            switch (State)
            {
                case MovementEngineState.Moving:
                    forces.Add(PlayerVehicle.Seek(positionToGoTo, 1));
                    break;

                case MovementEngineState.Following:
                    forces.Add(PlayerVehicle.Seek(positionToGoTo, 1));
                    break;
            }

            // move
            PlayerVehicle.Update(forces);
        }

        private Vector3 MoveAhead(Vector3 targetPosition, double offset)
        {
            float rotation = GetRotation.Invoke();
            double x = targetPosition.X + (Math.Cos(rotation) * offset);
            double y = targetPosition.Y + (Math.Sin(rotation) * offset);

            return new Vector3()
            {
                X = Convert.ToSingle(x),
                Y = Convert.ToSingle(y),
                Z = targetPosition.Z
            };
        }

        private void SetNewState(MovementEngineState state, Vector3 position)
        {
            Reset();
            State = state;
            TargetPosition = position;
        }

        private void Reset()
        {
            State = MovementEngineState.None;
            CurrentPath = new Queue<Vector3>();
        }
    }
}
