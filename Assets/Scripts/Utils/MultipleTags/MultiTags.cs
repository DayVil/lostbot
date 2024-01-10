using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Utils.MultipleTags
{
    public class MultiTags : MonoBehaviour
    {
        public List<EMultiTags> startTags = new();

        private readonly HashSet<EMultiTags> _multiTags = new();

        private void Start()
        {
            startTags.ForEach(AddTag);
        }

        public void AddTag(EMultiTags newTag)
        {
            _multiTags.Add(newTag);
        }

        public void RemoveTag(EMultiTags tagToRemove)
        {
            _multiTags.Remove(tagToRemove);
        }

        public bool HasTag(EMultiTags tagToCheck)
        {
            return _multiTags.Contains(tagToCheck);
        }

        public bool HasAnyTag(IEnumerable<EMultiTags> tagsToCheck)
        {
            return tagsToCheck.Any(tagToCheck => _multiTags.Contains(tagToCheck));
        }

        [CanBeNull]
        public static MultiTags GetMultiTags()
        {
            var multiTags = FindAnyObjectByType<MultiTags>();
            return multiTags != null ? multiTags : null;
        }
    }
}