using UnityEngine;

namespace DefenceOfTheHole.Data
{
    [CreateAssetMenu(fileName = "Research", menuName = "UI/Research")]
    public class Research : ScriptableObject
    {
        [SerializeField]
        private int _id;

        [SerializeField]
        private Texture2D _preview;

        [SerializeField]
        private string _title;

        [SerializeField]
        [TextArea]
        private string _description;

        [SerializeField]
        private Research _parent;

        public int Id => _id;

        public Texture2D Preview => _preview;
        
        public string Title => _title;
        
        public string Description => _description;
        
        public Research Parent => _parent;
    }
}
