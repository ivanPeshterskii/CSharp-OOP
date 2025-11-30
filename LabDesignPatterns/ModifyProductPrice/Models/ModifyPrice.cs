using System.Collections.Generic;
using ModifyProductPrice.Models.Interfaces;

public class ModifyPrice
{
    private List<ICommand> _commands = new List<ICommand>();

    public void SetCommand(ICommand command)
    {
        _commands.Add(command);
        command.Execute();
    }
}


