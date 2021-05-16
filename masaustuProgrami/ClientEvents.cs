using DataCore;

namespace masaustuProgrami
{
    public delegate void ClientConnecttionChanged(bool state);

    public delegate void ClientDataRead(HeaderData headerData, object data);
}