﻿namespace AreaTriangles;

public class Triangle
{
    private readonly double[] Points;
    const int pointsQuantity = 3;

    public Triangle(double[] points)
    {
        if (points.Length != pointsQuantity)
        {
            throw new ArgumentException("Um triangulo deve ter 3 pontas");
        }
        Points = points;
    }

    public double GetArea()
    {
        double p = (Points[0] + Points[1] + Points[2]) / 2;
        double area = Math.Sqrt(p * (p - Points[0]) * (p - Points[1]) * (p - Points[2]));
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
