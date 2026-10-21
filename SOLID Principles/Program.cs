using SOLIDPrinciples;

Console.WriteLine("=== SRP Violation ===");
SrpViolationDemo.Run();

Console.WriteLine("\n=== Following SRP ===");
SrpFollowDemo.Run();

// Day: Open-Closed Principle (OCP)
Console.WriteLine("\n=== OCP Violation ===");
OcpViolationDemo.Run();

Console.WriteLine("\n=== Following OCP ===");
OcpFollowingDemo.Run();