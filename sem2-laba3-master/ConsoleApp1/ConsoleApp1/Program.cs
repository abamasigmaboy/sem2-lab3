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

// Прямоугольный треугольник 
class RightTriangle : ITriangle
{
    protected double a, b;  // два катета

    public RightTriangle(double cat1, double cat2)
    {
        a = cat1;
        b = cat2;
    }

    public double GetArea() => a * b / 2;  // площадь

    // Периметр: катеты + гипотенуза
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

// Равнобедренный треугольник 
class IsoscelesTriangle : ITriangle
{
    protected double a, b, angle;  //две равные стороны и угол между ними в радианах

    public IsoscelesTriangle(double side, double angleDeg)
    {
        a = side;
        b = side;
        angle = angleDeg * Math.PI / 180;  //перевод градусов в радианы
    }

    // Площадь
    public double GetArea() => 0.5 * a * b * Math.Sin(angle);

    // Основание через теорему косинусов
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

//Равносторонний треугольник
class EquilateralTriangle : ITriangle
{
    protected double a;  // сторона

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
