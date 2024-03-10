namespace DesignPattern.Bridge
{
    // here will represent the implementation layer 
    public interface ILEDTV
    {
        void SwitchOn();
        void SwitchOff();
        void SetChannel(int channelNumber);

    }
}
