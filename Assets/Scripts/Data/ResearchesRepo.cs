using System;
using System.Linq;
using UnityEngine;

namespace DefenceOfTheHole.Data
{
    public static class ResearchesRepo
    {
        private readonly static Research[] researches;

        static ResearchesRepo()
        {
            researches = Resources.LoadAll<Research>("Researches");
        }

        public static Research Get(int id)
        {
            var result = researches.FirstOrDefault(research => research.Id == id);

            if (result == null)
            {
                throw new InvalidOperationException($"Не удалось найти исследование {id}.");
            }

            return result;
        }

        public static Research[] GetChildren(int parentId)
        {
            var result = researches
                .Where(research => research.Parent != null && research.Parent.Id == parentId)
                .ToArray();

            return result;
        }

        public static Research[] GetRoot()
        {
            var result = researches
                .Where(research => research.Parent == null)
                .ToArray();

            return result;
        }
    }
}
