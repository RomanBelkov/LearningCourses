using World.Humans;

namespace World.Factories
{
    internal interface IHumanFactory
    {
        Human CreateHuman(Sex sex);
    }
}