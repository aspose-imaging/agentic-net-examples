using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = "sample.apng";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access APNG-specific properties
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The file is not a valid APNG image.");
                    return;
                }

                // Retrieve loop count (NumPlays) and total frame count (PageCount)
                int loopCount = apng.NumPlays;
                int frameCount = apng.PageCount;

                // Display the metadata
                Console.WriteLine($"Loop count (NumPlays): {loopCount}");
                Console.WriteLine($"Total frame count (PageCount): {frameCount}");
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}