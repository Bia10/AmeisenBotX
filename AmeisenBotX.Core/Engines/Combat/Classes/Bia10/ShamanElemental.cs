﻿using AmeisenBotX.Core.Engines.Character.Comparators;
using AmeisenBotX.Core.Engines.Character.Talents.Objects;
using AmeisenBotX.Core.Engines.Combat.Helpers;
using AmeisenBotX.Core.Logic.Utils.Auras.Objects;
using AmeisenBotX.Wow.Objects.Enums;
using AmeisenBotX.Wow335a.Constants;
using System.Collections.Generic;

namespace AmeisenBotX.Core.Engines.Combat.Classes.Bia10
{
    public class ShamanElemental : BasicCombatClassBia10
    {
        public ShamanElemental(AmeisenBotInterfaces bot) : base(bot)
        {
            // my buffs
            MyAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, Shaman335a.LightningShield, () =>
                Bot.Player.ManaPercentage > 60.0 && TryCastSpell(Shaman335a.LightningShield, 0, true)));
            MyAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, Shaman335a.WaterShield, () =>
                Bot.Player.ManaPercentage < 20.0 && TryCastSpell(Shaman335a.WaterShield, 0, true)));
            // enemy debuffs
            TargetAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, Shaman335a.FlameShock, () =>
                TryCastSpell(Shaman335a.FlameShock, Bot.Wow.TargetGuid, true)));
            // interupts
            InterruptManager.InterruptSpells = new SortedList<int, InterruptManager.CastInterruptFunction>
            {
                { 0, x => TryCastSpell(Shaman335a.WindShear, x.Guid, true) },
                { 1, x => TryCastSpell(Shaman335a.Hex, x.Guid, true) }
            };
        }
        public override string Version => "1.0";
        public override string Description => "CombatClass for the Elemental Shaman spec.";
        public override string DisplayName => "Shaman Elemental";
        public override bool HandlesMovement => false;
        public override bool IsMelee => false;

        public override IItemComparator ItemComparator { get; set; } =
            new BasicIntellectComparator(null, new List<WowWeaponType>
            {
                WowWeaponType.ONEHANDED_AXES,
                WowWeaponType.ONEHANDED_MACES,
                WowWeaponType.ONEHANDED_SWORDS
            });

        public IEnumerable<int> BlacklistedTargetDisplayIds { get; set; }
        public IEnumerable<int> PriorityTargetDisplayIds { get; set; }

        public override WowClass WowClass => WowClass.Shaman;
        public override WowRole Role => WowRole.Dps;
        public Dictionary<string, dynamic> C { get; set; }

        public override TalentTree Talents { get; } = new()
        {
            Tree1 = new Dictionary<int, Talent>(),
            Tree2 = new Dictionary<int, Talent>(),
            Tree3 = new Dictionary<int, Talent>(),
        };

        public override bool UseAutoAttacks => true;
        public override bool WalkBehindEnemy => false;

        private bool HexedTarget { get; set; }
        private const int HealSelfPercentage = 60;

        public override void Execute()
        {
            base.Execute();

            if (Bot.Player.HealthPercentage < HealSelfPercentage)
                TryCastSpell(Shaman335a.HealingWave, Bot.Wow.PlayerGuid, true);
            if (IsInSpellRange(Bot.Target, Shaman335a.EarthShock))
                TryCastSpell(Shaman335a.EarthShock, Bot.Target.Guid, true);
            if (IsInSpellRange(Bot.Target, Shaman335a.LightningBolt))
                TryCastSpell(Shaman335a.LightningBolt, Bot.Target.Guid, true);
        }

        public override void OutOfCombatExecute()
        {
            base.OutOfCombatExecute();

            if (HandleDeadPartyMembers(Shaman335a.AncestralSpirit))
                return;
            if (CheckForWeaponEnchantment(WowEquipmentSlot.INVSLOT_MAINHAND,
                Shaman335a.RockbiterWeapon, Shaman335a.RockbiterWeapon))
                return;

            HexedTarget = false;
        }
    }
}