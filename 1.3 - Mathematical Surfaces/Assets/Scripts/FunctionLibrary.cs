using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName { Wave, ZWave, DoubleWave, MultiWave, Ripple, BigRipple, Circle, Cylinder, Sphere, TwistingSphere, Torus, TwistingTorus }
    
    static Function[] functions = { Wave, ZWave, DoubleWave, MultiWave, Ripple, BigRipple, Circle, Cylinder, Sphere, TwistingSphere, Torus, TwistingTorus };
    
    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }
    
    public static Vector3 Wave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * u + t);
        p.z = v;
        return p;
    }
    
    public static Vector3 ZWave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;
    }

    public static Vector3 DoubleWave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f *t));
        p.y += 0.5f * Sin(2f * PI * (u + t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }
    
    public static Vector3 MultiWave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f *t));
        p.y += 0.5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t)
    {
        float d = Abs(u);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d -t));
        p.y /= (1f + 10f * d);
        p.z = v;
        return p;
    }
    
    public static Vector3 BigRipple(float u, float v, float t)
    {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d -t));
        p.y /= (1f + 10f * d);
        p.z = v;
        return p;
    }
    
    public static Vector3 Circle(float u, float v, float t)
    {
        Vector3 p;
        p.x = Sin(PI * (u + (t * 0.1f)));
        p.y = 0f;
        p.z = Cos(PI * (u + (t * 0.1f)));
        return p;
    }
    
    public static Vector3 Cylinder(float u, float v, float t)
    {
        Vector3 p;
        p.x = Sin(PI * (u + (t * 0.1f)));
        p.y = v;
        p.z = Cos(PI * (u + (t * 0.1f)));
        return p;
    }
    
    public static Vector3 Sphere(float u, float v, float t)
    {
        float r = Cos(0.5f * PI * v);
        Vector3 p;
        p.x = r * Sin(PI * (u + (t * 0.1f)));
        p.y = Sin(PI * 0.5f * v);
        p.z = r * Cos(PI * (u + (t * 0.1f)));
        return p;
    }
    
    public static Vector3 TwistingSphere(float u, float v, float t)
    {
        float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * (u + (t * 0.1f)));
        p.y = r * Sin(PI * 0.5f * v);
        p.z = s * Cos(PI * (u + (t * 0.1f)));
        return p;
    }
    
    public static Vector3 Torus(float u, float v, float t)
    {
        float r1 = 0.75f;
        float r2 = 0.25f;
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * (u + (t * 0.1f)));
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * (u + (t * 0.1f)));
        return p;
    }
    
    public static Vector3 TwistingTorus(float u, float v, float t)
    {
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
        float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }
}