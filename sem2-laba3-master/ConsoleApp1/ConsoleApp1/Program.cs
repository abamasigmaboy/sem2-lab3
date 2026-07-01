Console.Write("Введите первый катет прямоугольного треугольника: ");
double cat1 = double.Parse(Console.ReadLine()!);
Console.Write("Введите второй катет прямоугольного треугольника: ");
double cat2 = double.Parse(Console.ReadLine()!);
RightTriangle rt = new RightTriangle(cat1, cat2);
Console.WriteLine(rt);
Console.Write("\nВведите боковую сторону равнобедренного треугольника: ");
double side = double.Parse(Console.ReadLine()!);
Console.Write("Введите угол при вершине (в градусах): ");
double angle = double.Parse(Console.ReadLine()!);
IsoscelesTriangle it = new IsoscelesTriangle(side, angle);
Console.WriteLine(it);
Console.Write("\nВведите сторону равностороннего треугольника: ");
double eqSide = double.Parse(Console.ReadLine()!);
EquilateralTriangle et = new EquilateralTriangle(eqSide);
Console.WriteLine(et);
interface ITriangle
{
    double GetArea();
    double GetPerimeter();
}
class RightTriangle : ITriangle
{
    protected double a, b;
    public RightTriangle(double cat1, double cat2)
    {
        a = cat1;
        b = cat2;
    }
    public double GetArea() => a * b / 2;
    public double GetPerimeter()
    {
        double c = Math.Sqrt(a * a + b * b);
        return a + b + c;
    }
    public override string ToString()
    {
        return $"Прямоугольный треугольник: площадь = {GetArea():F2}, периметр = {GetPerimeter():F2}";
    }
}
class IsoscelesTriangle : ITriangle
{
    protected double a, b, angle;
    public IsoscelesTriangle(double side, double angleDeg)
    {
        a = side;
        b = side;
        angle = angleDeg * Math.PI / 180;
    }
    public double GetArea() => 0.5 * a * b * Math.Sin(angle);
    public double GetPerimeter()
    {
        double c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle));
        return a + b + c;
    }
    public override string ToString()
    {
        return $"Равнобедренный треугольник: площадь = {GetArea():F2}, периметр = {GetPerimeter():F2}";
    }
}
class EquilateralTriangle : ITriangle
{
    protected double a;
    public EquilateralTriangle(double side)
    {
        a = side;
    }
    public double GetArea() => Math.Sqrt(3) / 4 * a * a;
    public double GetPerimeter() => 3 * a;
    public override string ToString()
    {
        return $"Равносторонний треугольник: площадь = {GetArea():F2}, периметр = {GetPerimeter():F2}";
    }
}