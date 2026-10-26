using SOLIDPrinciples;

Console.WriteLine("\n========== Single Responsibility Principle ==========");

Console.WriteLine("=== SRP Violation ===");
SrpViolationDemo.Run();

Console.WriteLine("\n=== Following SRP ===");
SrpFollowDemo.Run();

Console.WriteLine("\n========== Open Closed Principle ==========");

// Day: Open-Closed Principle (OCP)
Console.WriteLine("\n=== OCP Violation ===");
OcpViolationDemo.Run();

Console.WriteLine("\n=== Following OCP ===");
OcpFollowingDemo.Run();

Console.WriteLine("\n========== INTERFACE SEGREGATION PRINCIPLE ==========");

Console.WriteLine("\n=== Violating ISP ===");
IspViolationDemo.Run();

Console.WriteLine("\n=== Following ISP ===");
IspFollowingDemo.Run();
