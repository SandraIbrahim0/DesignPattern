namespace DesignPattern.Bridge
{
    // motivation to decoupled the Implementation and the abstraction levels 
    // to avoid the Crestian product where N * M ( N is the Implementation and M is the Absrtaction )

    // here will represent the AbstractionLayer
    public abstract class AbstractRemoteControl
    {
        protected ILEDTV ledTv;
        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(int channelNumber);
    }

}
