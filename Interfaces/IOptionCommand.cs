internal interface IOptionCommand
{
    string Display { get; }

    void Execute();
}