﻿using AmeisenBotX.Core.Character.Comparators;
using AmeisenBotX.Core.Data.Enums;
using AmeisenBotX.Core.Statemachine.Enums;
using AmeisenBotX.Logging;
using AmeisenBotX.Logging.Enums;
using System.Collections.Generic;
using static AmeisenBotX.Core.Statemachine.Utils.AuraManager;
using static AmeisenBotX.Core.Statemachine.Utils.InterruptManager;

namespace AmeisenBotX.Core.Statemachine.CombatClasses.Jannis
{
    public class DeathknightFrost : BasicCombatClass
    {
        // author: Jannis Höschele

        private readonly string armyOfTheDeadSpell = "Army of the Dead";
        private readonly string bloodPlagueSpell = "Blood Plague";
        private readonly string bloodStrikeSpell = "Blood Strike";
        private readonly string deathCoilSpell = "Death Coil";
        private readonly string frostFeverSpell = "Frost Fever";
        private readonly string frostPresenceSpell = "Frost Presence";
        private readonly string hornOfWinterSpell = "Horn of Winter";
        private readonly string iceboundFortitudeSpell = "Icebound Fortitude";
        private readonly string icyTouchSpell = "Icy Touch";
        private readonly string mindFreezeSpell = "Mind Freeze";
        private readonly string obliterateSpell = "Obliterate";
        private readonly string plagueStrikeSpell = "Plague Strike";
        private readonly string runeStrikeSpell = "Rune Strike";
        private readonly string strangulateSpell = "Strangulate";
        private readonly string unbreakableArmorSpell = "Unbreakable Armor";

        public DeathknightFrost(WowInterface wowInterface) : base(wowInterface)
        {
            MyAuraManager.BuffsToKeepActive = new Dictionary<string, CastFunction>()
            {
                { frostPresenceSpell, () => CastSpellIfPossibleDk(frostPresenceSpell) },
                { hornOfWinterSpell, () => CastSpellIfPossibleDk(hornOfWinterSpell, true) }
            };

            TargetAuraManager.DebuffsToKeepActive = new Dictionary<string, CastFunction>()
            {
                { frostFeverSpell, () => CastSpellIfPossibleDk(icyTouchSpell, false, false, false, true) },
                { bloodPlagueSpell, () => CastSpellIfPossibleDk(plagueStrikeSpell, false, false, false, true) }
            };

            TargetInterruptManager.InterruptSpells = new SortedList<int, CastInterruptFunction>()
            {
                { 0, () => CastSpellIfPossibleDk(mindFreezeSpell, true) },
                { 1, () => CastSpellIfPossibleDk(strangulateSpell, false, true) }
            };
        }

        public override string Author => "Jannis";

        public override WowClass Class => WowClass.Deathknight;

        public override Dictionary<string, dynamic> Configureables { get; set; } = new Dictionary<string, dynamic>();

        public override string Description => "FCFS based CombatClass for the Frost Deathknight spec.";

        public override string Displayname => "Deathknight Frost";

        public override bool HandlesMovement => false;

        public override bool HandlesTargetSelection => false;

        public override bool IsMelee => true;

        public override IWowItemComparator ItemComparator { get; set; } = new BasicStrengthComparator();

        public override CombatClassRole Role => CombatClassRole.Dps;

        public override string Version => "1.0";

        public override void Execute()
        {
            // we dont want to do anything if we are casting something...
            if (WowInterface.ObjectManager.Player.IsCasting)
            {
                return;
            }

            if (!WowInterface.ObjectManager.Player.IsAutoAttacking)
            {
                WowInterface.HookManager.StartAutoAttack();
                AmeisenLogger.Instance.Log(Displayname, $"Started Auto-Attacking", LogLevel.Verbose);
            }

            if (MyAuraManager.Tick()
                || TargetAuraManager.Tick()
                || TargetInterruptManager.Tick()
                || (WowInterface.ObjectManager.Player.HealthPercentage < 60
                    && CastSpellIfPossibleDk(iceboundFortitudeSpell, true))
                || CastSpellIfPossibleDk(unbreakableArmorSpell, false, false, true)
                || CastSpellIfPossibleDk(obliterateSpell, false, false, true, true)
                || CastSpellIfPossibleDk(bloodStrikeSpell, false, true)
                || CastSpellIfPossibleDk(deathCoilSpell, true)
                || (WowInterface.ObjectManager.Player.Runeenergy > 60
                    && CastSpellIfPossibleDk(runeStrikeSpell)))
            {
                return;
            }
        }

        public override void OutOfCombatExecute()
        {
            MyAuraManager.Tick();
        }
    }
}