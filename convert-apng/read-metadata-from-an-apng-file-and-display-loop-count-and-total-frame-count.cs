// HOW-TO: Read Loop Count And Frame Count From APNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int loopCount = apng.NumPlays;
                int frameCount = apng.PageCount;
                Console.WriteLine($"Loop Count: {loopCount}");
                Console.WriteLine($"Total Frame Count: {frameCount}");
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
 * 1. When you need to display how many times an animated PNG will repeat and how many frames it contains in a C# desktop application.
 * 2. When validating APNG files before uploading them to ensure they meet specific loop and frame requirements.
 * 3. When generating a report of animation metadata for a batch of APNG assets in a media management system.
 * 4. When debugging an animated image to confirm that the NumPlays and PageCount values are correctly set by the creator.
 * 5. When creating a UI that shows users the playback settings of an APNG, such as loop count and total frames, using Aspose.Imaging.
 */
