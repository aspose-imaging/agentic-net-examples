using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "sample.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access APNG-specific properties
            ApngImage apng = image as ApngImage;
            if (apng == null)
            {
                Console.WriteLine("The specified file is not a valid APNG image.");
                return;
            }

            // Retrieve loop count (NumPlays) and total frame count (PageCount)
            int loopCount = apng.NumPlays;      // 0 means infinite looping
            int frameCount = apng.PageCount;   // total number of frames

            // Display the metadata
            Console.WriteLine($"Loop count (NumPlays): {(loopCount == 0 ? "Infinite" : loopCount.ToString())}");
            Console.WriteLine($"Total frame count (PageCount): {frameCount}");
        }
    }
}