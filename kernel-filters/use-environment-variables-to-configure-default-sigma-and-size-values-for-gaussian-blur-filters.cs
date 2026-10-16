// HOW-TO: Apply Gaussian Blur with Configurable Sigma and Size via Environment Variables in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double sigma = 1.0;
            int size = 3;

            string sigmaEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIGMA");
            if (!string.IsNullOrEmpty(sigmaEnv) && double.TryParse(sigmaEnv, out double sigmaParsed))
            {
                sigma = sigmaParsed;
            }

            string sizeEnv = Environment.GetEnvironmentVariable("GAUSSIAN_SIZE");
            if (!string.IsNullOrEmpty(sizeEnv) && int.TryParse(sizeEnv, out int sizeParsed))
            {
                size = sizeParsed;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(size, sigma);
                image.Filter(image.Bounds, options);
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to apply a Gaussian blur to uploaded JPEG images and want the blur strength and kernel size to be adjustable without changing code, you can read sigma and size from environment variables.
 * 2. When deploying the same image‑processing service across development, staging, and production environments, you can set different GAUSSIAN_SIGMA and GAUSSIAN_SIZE values per environment to meet varying quality requirements.
 * 3. When integrating Aspose.Imaging into a CI/CD pipeline that processes screenshots, you can control the blur parameters through pipeline variables, allowing dynamic tuning for each build.
 * 4. When building a multi‑tenant web application that offers customizable image filters, you can store each tenant’s preferred blur settings in environment variables and apply them at runtime.
 * 5. When creating a command‑line tool that batch‑processes PNG files and needs a quick way for users to override default blur parameters, they can set GAUSSIAN_SIGMA and GAUSSIAN_SIZE before execution.
 */
