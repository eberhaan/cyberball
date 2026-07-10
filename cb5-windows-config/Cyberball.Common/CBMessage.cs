namespace Cyberball.Common
{
    public class CBMessage
    {
        public string message;
        /// <summary>
        /// If sender=0. It means this is an instruction given by the experimenter
        /// </summary>
        public int sender;
        private CBThrow _parentThrow;
        public decimal duration;


        public void SetParentThrow(CBThrow t)
        {
            _parentThrow = t;
        }

        public CBThrow GetParentThrow()
        {
            return _parentThrow;
        }
    }
}