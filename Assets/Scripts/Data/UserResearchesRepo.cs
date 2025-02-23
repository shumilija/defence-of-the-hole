using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace DefenceOfTheHole.Data
{
    public static class UserResearchesRepo
    {
        private const string _PlayerPrefsKey = "UserResearches";

        private static readonly List<UserResearch> userResearches;

        static UserResearchesRepo()
        {
            var json = PlayerPrefs.GetString(_PlayerPrefsKey);
            userResearches = JsonConvert.DeserializeObject<List<UserResearch>>(json) ?? new List<UserResearch>();

            Application.quitting += () =>
            {
                var json = JsonConvert.SerializeObject(userResearches);
                PlayerPrefs.SetString(_PlayerPrefsKey, json);
            };
        }

        public static event Action<UserResearch> LevelIncreased;

        public static void IncreaseLevel(int userId, int researchId, int value)
        {
            var updatedUserResearch = userResearches.FirstOrDefault(userResearch => userResearch.UserId == userId && userResearch.ResearchId == researchId);

            if (updatedUserResearch == null)
            {
                Create(userId, researchId, value);

                return;
            }

            if (updatedUserResearch.Level + value > UserResearch.MaxLevel)
            {
                throw new InvalidOperationException($"Невозможно поднять уровень исследования выше максимального {UserResearch.MaxLevel}.");
            }

            updatedUserResearch.Level += value;
            LevelIncreased?.Invoke(updatedUserResearch);
        }

        public static UserResearch Create(int userId, int researchId, int level = 0)
        {
            if (level > UserResearch.MaxLevel)
            {
                throw new InvalidOperationException($"Невозможно создать исследование с уровнем выше максимального {UserResearch.MaxLevel}.");
            }

            if (level < 0)
            {
                throw new InvalidOperationException($"Невозможно создать исследование с уровнем ниже 0.");
            }

            if (userResearches.Any(userResearch => userResearch.UserId == userId && userResearch.ResearchId == researchId))
            {
                throw new InvalidOperationException($"Исследование {researchId} для пользователя {userId} уже существует.");
            }

            var createdUserResearch = new UserResearch
            {
                UserId = userId,
                ResearchId = researchId,
                Level = level,
            };

            userResearches.Add(createdUserResearch);

            return createdUserResearch;
        }

        public static UserResearch Get(int userId, int researchId)
        {
            var result = userResearches.FirstOrDefault(userResearch => userResearch.UserId == userId && userResearch.ResearchId == researchId);

            if (result == null)
            {
                result = Create(userId, researchId);
            }

            return result;
        }
    }
}
