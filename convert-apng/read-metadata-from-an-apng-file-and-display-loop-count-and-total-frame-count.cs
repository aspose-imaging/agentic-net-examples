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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access APNG‑specific properties
            ApngImage apng = image as ApngImage;
            if (apng == null)
            {
                Console.WriteLine("The specified file is not a valid APNG image.");
                return;
            }

            // Loop count (NumPlays): 0 means infinite looping
            int loopCount = apng.NumPlays;
            // Total number of frames in the animation
            int frameCount = apng.PageCount;

            Console.WriteLine($"Loop count (NumPlays): {(loopCount == 0 ? "Infinite" : loopCount.ToString())}");
            Console.WriteLine($"Total frames: {frameCount}");
        }
    }
}