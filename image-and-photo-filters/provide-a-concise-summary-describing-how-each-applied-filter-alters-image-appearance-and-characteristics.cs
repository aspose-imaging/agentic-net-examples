using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Hardcoded input image path (required by the safety rules)
        string inputPath = @"c:\temp\sample.png";

        // Hardcoded output text file path for the filter summary
        string outputPath = @"c:\temp\filter_summary.txt";

        // Verify that the input image exists; do not throw exceptions
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists before saving the summary
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Build a concise description for each filter
        string summary =
            "Median Filter: Replaces each pixel with the median value of its surrounding neighborhood, reducing salt‑and‑pepper noise while preserving edges.\n" +
            "Bilateral Smoothing Filter: Smooths colors while keeping edges sharp by considering both spatial proximity and color similarity.\n" +
            "Gaussian Blur Filter: Applies a Gaussian kernel to blur the image, producing a soft, out‑of‑focus effect; larger radius/sigma increase blur.\n" +
            "Gauss‑Wiener Filter: Performs adaptive smoothing based on local variance, reducing noise while preserving details better than simple blur.\n" +
            "Motion Wiener Filter: Simulates motion blur along a specified angle and length, then applies Wiener de‑convolution to reduce noise.\n" +
            "Sharpen Filter: Enhances edges by emphasizing high‑frequency components; larger kernel/sigma increase contrast around edges.\n" +
            "ImageFilterType Enum:\n" +
            "  None – No filtering applied.\n" +
            "  BigRectangular – Uses a larger rectangular kernel for smoothing.\n" +
            "  SmallRectangular – Uses a smaller rectangular kernel for subtle smoothing.\n";

        // Write the summary to the output file
        File.WriteAllText(outputPath, summary);

        // Also output to console for immediate feedback
        Console.WriteLine("Filter summary written to: " + outputPath);
    }
}