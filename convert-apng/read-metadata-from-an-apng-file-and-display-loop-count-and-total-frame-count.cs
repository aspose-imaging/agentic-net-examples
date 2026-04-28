using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "input.apng";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access APNG-specific properties
                ApngImage apng = image as ApngImage;
                if (apng != null)
                {
                    // Retrieve loop count (NumPlays) and total frame count (PageCount)
                    int loopCount = apng.NumPlays;
                    int frameCount = apng.PageCount;

                    Console.WriteLine($"Loop count: {loopCount}");
                    Console.WriteLine($"Total frames: {frameCount}");
                }
                else
                {
                    Console.WriteLine("The specified file is not an APNG image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}