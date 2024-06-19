namespace AreaTriangles;

public class Triangle
{
    private readonly double[] _points;
    const int pointsQuantity = 3;

    public Triangle(double[] points)
    {
        if (points.Length != pointsQuantity)
        {
            throw new ArgumentException("Um triangulo deve ter 3 pontas");
        }
        _points = points;
    }

    public double GetArea()
    {
        double p = (_points[0] + _points[1] + _points[2]) / 2;
        double area = Math.Sqrt(p * (p - _points[0]) * (p - _points[1]) * (p - _points[2]));
        return area;
    }
    static public double WhatIsBiggest(Triangle[] triangles)
    {
        double biggestArea = 0;
        foreach (Triangle triangle in triangles)
        {
            double area = triangle.GetArea();
            if (area > biggestArea)
            {
                biggestArea = area;
            }
        }
        return biggestArea;
    }
}
