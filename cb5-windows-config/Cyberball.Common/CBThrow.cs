namespace Cyberball.Common
{
    public class CBThrow
    {
        private string _throwName;
        private int delay;
        public bool isChatMessage;
        public CBMessage msg;

        public bool IsInstruction { get; set; }
        //public string InstructionText { get; set; }

        public CBThrow()
        {
            ThrowName = "New Throw";
        }

        public string ThrowName
        {
            get
            {
                if (string.IsNullOrEmpty(_throwName))
                    return "(untitled)";
                return _throwName;
            }
            set { _throwName = value; }
        }

        public string ThrowTo { get; set; }

        public int Delay
        {
            get { return delay; }
            set
            {
                delay = value;
                if (delay < 0)
                {
                    delay = 0;
                }
            }
        }
    }
}