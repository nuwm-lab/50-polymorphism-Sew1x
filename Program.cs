
using System;

abstract class DroblinBase {
	public abstract void InputCoefficients();
	public abstract void PrintCoefficients();
	public abstract double Calculate(double x);
}

class DroblinFunction : DroblinBase {
	double a1, a0, b1, b0;
	public DroblinFunction() {}
	public DroblinFunction(double[] coeffs) {
		if (coeffs.Length == 4) {
			a1 = coeffs[0]; a0 = coeffs[1]; b1 = coeffs[2]; b0 = coeffs[3];
		}
	}
	public override void InputCoefficients() {
		Console.Write("a1 a0 b1 b0: ");
		var vals = Console.ReadLine().Split();
		a1 = double.Parse(vals[0]); a0 = double.Parse(vals[1]);
		b1 = double.Parse(vals[2]); b0 = double.Parse(vals[3]);
	}
	public void InputCoefficients(double[] coeffs) {
		if (coeffs.Length == 4) {
			a1 = coeffs[0]; a0 = coeffs[1]; b1 = coeffs[2]; b0 = coeffs[3];
		}
	}
	public override void PrintCoefficients() {
		Console.WriteLine($"({a1}*x+{a0})/({b1}*x+{b0})");
	}
	public override double Calculate(double x) {
		var denom = b1*x+b0;
		if (denom==0) { Console.WriteLine("Знаменник=0"); return double.NaN; }
		return (a1*x+a0)/denom;
	}
}

class DroblinQuadraticFunction : DroblinBase {
	double a2, a1, a0, b2, b1, b0;
	public DroblinQuadraticFunction() {}
	public DroblinQuadraticFunction(double[] coeffs) {
		if (coeffs.Length == 6) {
			a2 = coeffs[0]; a1 = coeffs[1]; a0 = coeffs[2];
			b2 = coeffs[3]; b1 = coeffs[4]; b0 = coeffs[5];
		}
	}
	public override void InputCoefficients() {
		Console.Write("a2 a1 a0 b2 b1 b0: ");
		var vals = Console.ReadLine().Split();
		a2 = double.Parse(vals[0]); a1 = double.Parse(vals[1]); a0 = double.Parse(vals[2]);
		b2 = double.Parse(vals[3]); b1 = double.Parse(vals[4]); b0 = double.Parse(vals[5]);
	}
	public void InputCoefficients(double[] coeffs) {
		if (coeffs.Length == 6) {
			a2 = coeffs[0]; a1 = coeffs[1]; a0 = coeffs[2];
			b2 = coeffs[3]; b1 = coeffs[4]; b0 = coeffs[5];
		}
	}
	public override void PrintCoefficients() {
		Console.WriteLine($"({a2}*x^2+{a1}*x+{a0})/({b2}*x^2+{b1}*x+{b0})");
	}
	public override double Calculate(double x) {
		var denom = b2*x*x+b1*x+b0;
		if (denom==0) { Console.WriteLine("Знаменник=0"); return double.NaN; }
		return (a2*x*x+a1*x+a0)/denom;
	}
}

class Program {
	static void Main() {
		while (true) {
			Console.Write("1-лінійна, 2-квадр, вихід: ");
			var ch = Console.ReadLine();
			DroblinBase func = ch=="1" ? new DroblinFunction() : ch=="2" ? new DroblinQuadraticFunction() : null;
			if (func==null) break;
			func.InputCoefficients();
			func.PrintCoefficients();
			Console.Write("x0: ");
			if (double.TryParse(Console.ReadLine(), out double x0))
				Console.WriteLine($"f({x0}) = {func.Calculate(x0)}");
		}
	}
}
