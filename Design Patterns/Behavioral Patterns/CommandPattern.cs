// Command Pattern: It encapsulates a request or operation as an object, separating the object that requests an action from the object that actually performs it.
// Instead of directly calling a method on an object, we create a command object that represents the action. The command can be executed by another object.

using System;

namespace DesignPatterns.BehavioralPatterns
{
    // 1. Command Interface
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // 2. Receiver
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("light is ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is OFF.");
        }
    }

    // 3. Concrete Command - Turn On
    public class TurnOnCommand : ICommand
    {
        private readonly Light _light;
        public TurnOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
        public void Undo()
        {
            _light.TurnOff();
        }
    }

    // 4. Concrete Command - Turn Off
    public class TurnOffCommand : ICommand
    {
        private readonly Light _light;
        public TurnOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }

    // 5. Invoker
    public class RemoteControl
    {
        private ICommand _command;
        public void SetCommand(ICommand command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        public void PressButton()
        {
            _command.Execute();
        }

        public void PressUndo()
        {
            _command.Undo();
        }
    }

    // 6. Client / Program Entry Point
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Receiver
            Light light = new Light();

            // Create commands
            ICommand turnOn = new TurnOnCommand(light);
            ICommand turnOff = new TurnOffCommand(light);

            // Create Invoker
            RemoteControl remote = new RemoteControl();

            // Assign and execute Turn on command
            remote.SetCommand(turnOn);
            remote.PressUndo();

            // Undo previous command
            remote.PressUndo();

            // Assign and exexcute Turn Off Command
            remote.SetCommand(turnOff);
            remote.PressButton();

            // Undo previous command
            remote.PressUndo();
        }
    }
}