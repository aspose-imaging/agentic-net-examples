using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <input_apng_path> <output_apng_path>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the existing APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Iterate through each frame and apply a chain of filters
            for (int i = 0; i < apng.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apng.Pages[i];

                // Apply Gaussian blur
                frame.Filter(
                    frame.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Apply sharpen filter
                frame.Filter(
                    frame.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Apply motion wiener filter
                frame.Filter(
                    frame.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));
            }

            // Save the modified APNG using ApngOptions
            apng.Save(outputPath, new ApngOptions());
        }
    }
}