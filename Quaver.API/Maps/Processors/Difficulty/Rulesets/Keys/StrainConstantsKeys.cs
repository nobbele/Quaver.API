using Quaver.API.Maps.Processors.Difficulty.Optimization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quaver.API.Maps.Processors.Difficulty.Rulesets.Keys
{
    public class StrainConstantsKeys : StrainConstants
    {
        /// <summary>
        ///     Base Difficulty Multiplier
        /// </summary>
        public float DifficultyMultiplier { get; } = 4.3f;

        /// <summary>
        ///     Base Offset Value. Difficulty will be subtracted by this value.
        ///     - Lowest Difficulty possible in HandState is 1. 
        /// </summary>
        public float DifficultyOffset { get; } = -22f;

        /// <summary>
        ///     Any two states with intervals below this value will be considered vibro.
        ///     - a 1/4 170bpm jack has an interval of 88.235ms
        /// </summary>
        public float VibroActionToleranceMs { get; } = 88.2f;

        /// <summary>
        ///     Any two states with intervals below this value will fall under the Vibro gradient.
        ///     - a 1/4 150bpm jack has an interval of 100ms
        /// </summary>
        public float VibroActionThresholdMs { get; } = 100;

        /// <summary>
        /// Max Absolute Delta between two Simple Jack Actions to be considered as repetition.
        /// </summary>
        public float WristGapDeltaThresholdMs { get; } = 26;

        /// <summary>
        ///     Max Repetition for Simple Jack. Will not count simple jacks that repeat after this.
        /// </summary>
        public int MaxSimpleJackRepetition { get; } = 30;

        /// <summary>
        ///     Max Delta between two objects for stamina calculation.
        /// </summary>
        public float MaxStaminaDelta { get; } = 1000;

        /// <summary>
        ///     Spline Multiplier for Hand States that have higher Difficulty than the previous predecessor 
        /// </summary>
        public DynamicVariable StaminaIncrementalMultiplier { get; set; }

        /// <summary>
        ///     Spline Multiplier for Hand States that have lower Difficulty than the previous predecessor 
        /// </summary>
        public DynamicVariable StaminaDecrementalMultiplier { get; set; }

        /// <summary>
        ///     Difficulty Multiplier for Technical Jacks.
        ///     - Technical Jacks are Jacks that have different Hand States in succession.
        /// </summary>
        public DynamicVariable WristTechMultiplier { get; set; }

        /// <summary>
        ///     Difficulty Multiplier for Simple Jacks.
        ///     - Simple Jacks are Jacks that repeat same Hand State in succession.
        /// </summary>
        public DynamicVariable WristSimpleJackMultiplier { get; set; }

        /// <summary>
        ///     Difficulty Multiplier that applies exponentially to Simple Jacks that repeat.
        /// </summary>
        public DynamicVariable WristRepetitionMultiplier { get; set; }

        /// <summary>
        ///     Difficulty Multiplier for fast Simple Jacks.
        ///     - Speed is determined by VibroActionToleranceMs.
        /// </summary>
        public DynamicVariable WristVibroMultiplier { get; set; }

        /// <summary>
        ///     Difficulty Multiplier for Gaps in Simple Jacks.
        ///     - Appropriate gaps are determined by WristGapSigmaThresholdMs
        /// </summary>
        public DynamicVariable WristGapMultiplier { get; set; }

        /// <summary>
        ///     Difficulty Multiplier for Two Handed Chords.
        /// </summary>
        public DynamicVariable TwoHandedChordMultiplier { get; set; }

        /// <summary>
        ///     Constructor. Create default strain constant values.
        /// </summary>
        public StrainConstantsKeys()
        {
            StaminaIncrementalMultiplier = NewConstant("StaminaIncrementalMultiplier", 0.6317447f);
            StaminaDecrementalMultiplier = NewConstant("StaminaDecrementalMultiplier", 0.1270299f);
            WristRepetitionMultiplier = NewConstant("WristRepetitionMultiplier", 0.9925058f);
            WristTechMultiplier = NewConstant("WristTechMultiplier", 1.245176f);
            WristGapMultiplier = NewConstant("WristGapMultiplier", 1.069906f);
            WristVibroMultiplier = NewConstant("WristVibroMultiplier", 0.918826f);
            WristSimpleJackMultiplier = NewConstant("WristSimpleJackMultiplier", 0.9705446f);
            TwoHandedChordMultiplier = NewConstant("ChordMultiplier", 0.9115574f);
        }
    }
}
