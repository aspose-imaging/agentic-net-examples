using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.png";
            string outputSharpenPath = "output_sharpen.png";
            string outputGaussianPath = "output_gaussian.png";

            // Verify input exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputSharpenPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputGaussianPath));

            // ---------- Sharpen Filter ----------
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                raster.Save(outputSharpenPath);
            }

            // ---------- Gaussian Blur Filter ----------
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputGaussianPath);
            }

            // Compute SHA256 hashes
            string ComputeHash(string filePath)
            {
                using (var sha = System.Security.Cryptography.SHA256.Create())
                {
                    byte[] hashBytes = sha.ComputeHash(File.ReadAllBytes(filePath));
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                }
            }

            string sharpenHash = ComputeHash(outputSharpenPath);
            string gaussianHash = ComputeHash(outputGaussianPath);

            // Expected hash values (replace with actual expected hashes)
            const string expectedSharpenHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            const string expectedGaussianHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";

            // Compare and report
            if (sharpenHash == expectedSharpenHash)
                Console.WriteLine("Sharpen filter output matches expected hash.");
            else
                Console.WriteLine($"Sharpen filter hash mismatch: {sharpenHash}");

            if (gaussianHash == expectedGaussianHash)
                Console.WriteLine("Gaussian blur filter output matches expected hash.");
            else
                Console.WriteLine($"Gaussian blur filter hash mismatch: {gaussianHash}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to create an automated integration test that verifies the Aspose.Imaging sharpen filter produces the exact same PNG output across different build environments by comparing SHA‑256 hashes.
 * 2. When a CI/CD pipeline must confirm that a recent upgrade of Aspose.Imaging does not change the visual result of a Gaussian blur operation on a PNG file, using hash comparison as a regression guard.
 * 3. When a quality‑assurance team wants to ensure that image preprocessing for a machine‑learning model consistently applies both sharpening and blur filters before training, and they validate the processed images with cryptographic hashes.
 * 4. When a developer is building a cross‑platform image‑processing service that must guarantee identical PNG outputs for sharpened and blurred assets, and they use integration tests with SHA‑256 to detect any deviation.
 * 5. When a software vendor needs to certify that their document‑to‑image conversion workflow applies the correct filter settings (radius 5, sigma 4.0) and produces reproducible PNG results, verified by comparing expected hash values in automated tests.
 */