#! python3

import os, sys, shutil

solver_code = """namespace <NAMESPACE>;

public static class Solver
{
    public static object Part1()
    {
        return null!;
    }

    public static object Part2()
    {
        return null!;
    }
}"""

solution_code = """using System;
using utils;

namespace <NAMESPACE>;

public class Solution : ISolution
{
    public static void Main()
    {
        var solution = new Solution();
        Console.WriteLine($"Part1: {solution.SolvePart1()}");
        Console.WriteLine($"Part2: {solution.SolvePart2()}");
    }

    public object SolvePart1()
    {
        return Solver.Part1();
    }

    public object SolvePart2()
    {
        return Solver.Part2();
    }
}"""

tests_code = """using NUnit.Framework;

namespace <NAMESPACE>;

public class SolverTests
{
    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(), Is.Null);
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(), Is.Null);
    }
}
"""

project = sys.argv[1]

lib = f"{project}"
os.system(f"dotnet new classlib --no-restore -o {lib}")
os.remove(f"{lib}/Class1.cs")
with open(f"{lib}/Solver.cs", "w") as f:
	f.write(solver_code.replace("<NAMESPACE>", lib.replace("-", "_")))

app = f"{project}.app"
os.system(f"dotnet new console --no-restore -o {app}")
os.remove(f"{app}/Program.cs")
with open(f"{app}/Solution.cs", "w") as f:
	f.write(solution_code.replace("<NAMESPACE>", app.replace("-", "_")))

tests = f"{project}.tests"
os.system(f"dotnet new nunit --no-restore -o {tests}")
os.remove(f"{tests}/UnitTest1.cs")
with open(f"{tests}/SolverTests.cs", "w") as f:
	f.write(tests_code.replace("<NAMESPACE>", tests.replace("-", "_")))

os.system(f"dotnet add {app} reference utils")
os.system(f"dotnet add {app} reference {lib}")
os.system(f"dotnet add {tests} reference {lib}")

os.system(f"dotnet sln add {lib}")
os.system(f"dotnet sln add {app}")
os.system(f"dotnet sln add {tests}")
