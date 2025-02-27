﻿using AmeisenBotX.Common.Math;
using AmeisenBotX.Core.Engines.Dungeon.Enums;
using AmeisenBotX.Core.Engines.Dungeon.Objects;
using AmeisenBotX.Wow.Objects.Enums;
using System.Collections.Generic;

namespace AmeisenBotX.Core.Engines.Dungeon.Profiles.TBC
{
    public class TheSlavePensProfile : IDungeonProfile
    {
        public string Author { get; } = "Jannis";

        public string Description { get; } = "Profile for the Dungeon in Outland, made for Level 60 to 64.";

        public Vector3 DungeonExit { get; } = new(119, 136, -1);

        public DungeonFactionType FactionType { get; } = DungeonFactionType.Neutral;

        public int GroupSize { get; } = 5;

        public WowMapId MapId { get; } = WowMapId.TheSlavePens;

        public int MaxLevel { get; } = 64;

        public string Name { get; } = "[60-64] The Slave Pens";

        public List<DungeonNode> Nodes { get; private set; } = new()
        {
            new(new(120, -132, -1)),
            new(new(122, -124, 0)),
            new(new(125, -117, -1)),
            new(new(123, -109, -1)),
            new(new(118, -103, -2)),
            new(new(112, -98, -2)),
            new(new(108, -91, -2)),
            new(new(104, -84, -2)),
            new(new(99, -78, -2)),
            new(new(93, -73, -2)),
            new(new(86, -69, -2)),
            new(new(79, -65, -2)),
            new(new(72, -61, -1)),
            new(new(65, -57, -1)),
            new(new(58, -52, -1)),
            new(new(51, -48, -2)),
            new(new(45, -43, -1)),
            new(new(38, -39, -1)),
            new(new(31, -35, -1)),
            new(new(24, -32, -1)),
            new(new(17, -28, -1)),
            new(new(10, -25, -1)),
            new(new(3, -22, -2)),
            new(new(-4, -18, -2)),
            new(new(-11, -15, -2)),
            new(new(-18, -12, -2)),
            new(new(-24, -7, -1)),
            new(new(-32, -6, -1)),
            new(new(-40, -8, -1)),
            new(new(-48, -9, -2)),
            new(new(-56, -9, -3)),
            new(new(-64, -8, -4)),
            new(new(-72, -7, -6)),
            new(new(-80, -6, -8)),
            new(new(-88, -6, -8)),
            new(new(-96, -6, -9)),
            new(new(-103, -9, -10)),
            new(new(-110, -13, -9)),
            new(new(-115, -20, -8)),
            new(new(-116, -28, -6)),
            new(new(-114, -36, -5)),
            new(new(-111, -43, -4)),
            new(new(-109, -51, -4)),
            new(new(-107, -59, -3)),
            new(new(-105, -67, -3)),
            new(new(-104, -75, -4)),
            new(new(-102, -83, -4)),
            new(new(-100, -91, -4)),
            new(new(-99, -99, -4)),
            new(new(-99, -107, -4)),
            new(new(-99, -115, -3)),
            new(new(-100, -123, -2)),
            new(new(-104, -130, -2)),
            new(new(-109, -136, -1)),
            new(new(-109, -144, -2)),
            new(new(-103, -149, -2)),
            new(new(-95, -151, -2)),
            new(new(-87, -153, -2)),
            new(new(-79, -155, -2)),
            new(new(-71, -158, -2)),
            new(new(-64, -161, -2)),
            new(new(-57, -165, -2)),
            new(new(-50, -169, -2)),
            new(new(-43, -172, -2)),
            new(new(-36, -176, -2)),
            new(new(-29, -181, -2)),
            new(new(-23, -187, -2)),
            new(new(-18, -193, -2)),
            new(new(-16, -201, -2)),
            new(new(-16, -209, -2)),
            new(new(-14, -217, -2)),
            new(new(-13, -225, -2)),
            new(new(-14, -233, -2)),
            new(new(-16, -241, -2)),
            new(new(-18, -249, -2)),
            new(new(-20, -257, -1)),
            new(new(-23, -264, -1)),
            new(new(-25, -272, -1)),
            new(new(-27, -280, -1)),
            new(new(-29, -288, -1)),
            new(new(-31, -296, -1)),
            new(new(-24, -299, 0)),
            new(new(-17, -302, 2)),
            new(new(-9, -304, 3)),
            new(new(-1, -306, 3)),
            new(new(7, -309, 3)),
            new(new(15, -311, 3)),
            new(new(23, -313, 3)),
            new(new(31, -315, 3)),
            new(new(39, -317, 3)),
            new(new(47, -319, 3)),
            new(new(55, -321, 3)),
            new(new(63, -323, 3)),
            new(new(71, -325, 3)),
            new(new(79, -327, 3)),
            new(new(87, -330, 3)),
            new(new(87, -338, 3)),
            new(new(81, -343, 3)),
            new(new(75, -348, 3)),
            new(new(69, -353, 3)),
            new(new(62, -357, 3)),
            new(new(55, -361, 3)),
            new(new(47, -364, 3)),
            new(new(41, -370, 3)),
            new(new(43, -378, 3)),
            new(new(50, -381, 3)),
            new(new(58, -381, 3)),
            new(new(66, -381, 5)),
            new(new(74, -380, 8)),
            new(new(81, -380, 11)),
            new(new(88, -380, 14)),
            new(new(95, -380, 18)),
            new(new(102, -380, 22)),
            new(new(109, -380, 25)),
            new(new(116, -381, 28)),
            new(new(124, -381, 30)),
            new(new(127, -374, 31)),
            new(new(124, -367, 31)),
            new(new(116, -365, 31)),
            new(new(108, -363, 32)),
            new(new(101, -360, 33)),
            new(new(93, -358, 34)),
            new(new(85, -356, 34)),
            new(new(78, -354, 36)),
            new(new(71, -351, 38)),
            new(new(63, -349, 39)),
            new(new(55, -347, 42)),
            new(new(47, -347, 45)),
            new(new(39, -346, 47)),
            new(new(32, -346, 50)),
            new(new(25, -345, 53)),
            new(new(18, -346, 56)),
            new(new(11, -346, 59)),
            new(new(4, -346, 63)),
            new(new(-3, -347, 66)),
            new(new(-10, -348, 69)),
            new(new(-17, -351, 72)),
            new(new(-24, -353, 75)),
            new(new(-31, -355, 77)),
            new(new(-38, -360, 79)),
            new(new(-44, -365, 80)),
            new(new(-50, -370, 81)),
            new(new(-56, -375, 81)),
            new(new(-63, -379, 80)),
            new(new(-71, -380, 79)),
            new(new(-79, -380, 79)),
            new(new(-87, -381, 79)),
            new(new(-95, -381, 79)),
            new(new(-103, -381, 80)),
            new(new(-111, -380, 81)),
            new(new(-116, -374, 81)),
            new(new(-121, -367, 81)),
            new(new(-127, -362, 80)),
            new(new(-134, -358, 78)),
            new(new(-141, -354, 76)),
            new(new(-148, -351, 74)),
            new(new(-155, -350, 71)),
            new(new(-162, -349, 68)),
            new(new(-169, -348, 65)),
            new(new(-176, -348, 61)),
            new(new(-183, -349, 57)),
            new(new(-188, -353, 53)),
            new(new(-199, -369, 7)),
            new(new(-203, -376, 7)),
            new(new(-208, -382, 8)),
            new(new(-216, -382, 8)),
            new(new(-223, -381, 4)),
            new(new(-231, -379, 3)),
            new(new(-238, -380, 6)),
            new(new(-245, -380, 9)),
            new(new(-252, -380, 12)),
            new(new(-259, -380, 15)),
            new(new(-266, -380, 19)),
            new(new(-273, -380, 23)),
            new(new(-280, -380, 26)),
            new(new(-287, -380, 29)),
            new(new(-280, -381, 26)),
            new(new(-273, -381, 23)),
            new(new(-266, -381, 19)),
            new(new(-259, -381, 16)),
            new(new(-252, -382, 12)),
            new(new(-245, -382, 9)),
            new(new(-238, -385, 6)),
            new(new(-231, -389, 4)),
            new(new(-230, -397, 3)),
            new(new(-236, -403, 3)),
            new(new(-243, -406, 3)),
            new(new(-250, -410, 3)),
            new(new(-251, -418, 3)),
            new(new(-253, -426, 3)),
            new(new(-248, -432, 3)),
            new(new(-240, -434, 3)),
            new(new(-232, -436, 3)),
            new(new(-224, -438, 3)),
            new(new(-216, -440, 3)),
            new(new(-208, -442, 3)),
            new(new(-200, -444, 3)),
            new(new(-192, -446, 3)),
            new(new(-184, -448, 3)),
            new(new(-176, -450, 3)),
            new(new(-168, -453, 3)),
            new(new(-161, -456, 3)),
            new(new(-154, -460, 2)),
            new(new(-147, -464, 1)),
            new(new(-140, -468, -1)),
            new(new(-133, -473, -1)),
            new(new(-125, -474, -1)),
            new(new(-117, -473, -1)),
            new(new(-110, -470, -1)),
            new(new(-102, -468, -1)),
            new(new(-95, -465, -1)),
            new(new(-88, -460, -2)),
            new(new(-81, -457, -2)),
            new(new(-73, -457, -2)),
            new(new(-65, -457, -2)),
            new(new(-57, -458, -2)),
            new(new(-49, -458, -2)),
            new(new(-41, -459, -2)),
            new(new(-33, -459, -2)),
            new(new(-25, -459, 0)),
            new(new(-17, -458, 2)),
            new(new(-9, -458, 3)),
            new(new(-1, -457, 3)),
            new(new(-8, -454, 3)),
            new(new(-16, -456, 2)),
            new(new(-24, -458, 1)),
            new(new(-32, -459, -1)),
            new(new(-40, -461, -2)),
            new(new(-48, -463, -2)),
            new(new(-56, -464, -2)),
            new(new(-64, -466, -2)),
            new(new(-72, -468, -2)),
            new(new(-79, -471, -2)),
            new(new(-82, -478, -2)),
            new(new(-83, -486, -2)),
            new(new(-84, -494, -2)),
            new(new(-84, -502, -2)),
            new(new(-82, -510, -2)),
            new(new(-77, -516, -2)),
            new(new(-72, -523, -2)),
            new(new(-69, -530, -2)),
            new(new(-67, -538, -2)),
            new(new(-65, -546, -2)),
            new(new(-65, -554, -1)),
            new(new(-68, -561, -1)),
            new(new(-71, -568, 0)),
            new(new(-75, -575, 1)),
            new(new(-80, -582, 1)),
            new(new(-84, -589, 3)),
            new(new(-90, -594, 5)),
            new(new(-95, -600, 7)),
            new(new(-97, -608, 10)),
            new(new(-97, -615, 13)),
            new(new(-98, -622, 16)),
            new(new(-99, -630, 18)),
            new(new(-100, -638, 20)),
            new(new(-101, -646, 19)),
            new(new(-100, -654, 21)),
            new(new(-99, -661, 25)),
            new(new(-98, -668, 28)),
            new(new(-96, -675, 31)),
            new(new(-94, -682, 33)),
            new(new(-91, -690, 35)),
            new(new(-89, -698, 36)),
            new(new(-87, -706, 37)),
            new(new(-85, -714, 37)),
            new(new(-83, -722, 37)),
            new(new(-82, -730, 37)),
            new(new(-82, -738, 37)),
            new(new(-89, -743, 37)),
            new(new(-96, -747, 37)),
            new(new(-103, -751, 37)),
            new(new(-111, -752, 37)),
            new(new(-119, -751, 37)),
            new(new(-127, -750, 38)),
            new(new(-135, -749, 38)),
            new(new(-142, -746, 38)),
            new(new(-149, -742, 38)),
            new(new(-156, -737, 38)),
            new(new(-163, -733, 38)),
            new(new(-170, -728, 38)),
            new(new(-177, -724, 38)),
            new(new(-185, -722, 38)),
            new(new(-193, -722, 38)),
            new(new(-201, -722, 37)),
            new(new(-209, -722, 36)),
            new(new(-216, -719, 36)),
            new(new(-224, -716, 37)),
            new(new(-232, -713, 37)),
            new(new(-240, -710, 37)),
            new(new(-247, -707, 37)),
            new(new(-254, -704, 37)),
            new(new(-261, -700, 37)),
            new(new(-268, -697, 37)),
            new(new(-275, -693, 37)),
            new(new(-282, -690, 37)),
            new(new(-284, -683, 35)),
            new(new(-282, -675, 35)),
            new(new(-277, -669, 35)),
            new(new(-270, -672, 35)),
            new(new(-263, -676, 35)),
            new(new(-257, -681, 35)),
            new(new(-250, -685, 35)),
            new(new(-244, -690, 35)),
            new(new(-237, -694, 35)),
            new(new(-230, -698, 35)),
            new(new(-224, -703, 35)),
            new(new(-217, -707, 35)),
            new(new(-210, -712, 36)),
            new(new(-204, -717, 37)),
            new(new(-202, -725, 37)),
            new(new(-199, -733, 36)),
            new(new(-197, -741, 36)),
            new(new(-195, -749, 37)),
            new(new(-193, -756, 40)),
            new(new(-190, -763, 42)),
            new(new(-183, -768, 43)),
            new(new(-181, -776, 44)),
            new(new(-185, -783, 44)),
            new(new(-189, -790, 44)),
            new(new(-191, -798, 44), DungeonNodeType.Use),
        };

        public List<int> PriorityUnits { get; } = new();

        public int RequiredItemLevel { get; } = 65;

        public int RequiredLevel { get; } = 60;

        public Vector3 WorldEntry { get; } = new(737, 7017, -71);

        public WowMapId WorldEntryMapId { get; } = WowMapId.Outland;
    }
}