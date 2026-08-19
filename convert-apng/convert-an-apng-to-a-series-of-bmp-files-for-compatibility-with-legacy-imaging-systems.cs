// HOW-TO: Extract APNG Frames to BMP Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputDirectory = "output";
        string outputPattern = Path.Combine(outputDirectory, "frame_{0}.bmp");

        // Ensure output directory exists before any save operation
        Directory.CreateDirectory(outputDirectory);

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The provided file is not a valid APNG image.");
                    return;
                }

                // Iterate through each frame and save as BMP
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Retrieve the frame (each page is an Image)
                    Image frame = apng.Pages[i];

                    // Build output file path for the current frame
                    string outputPath = string.Format(outputPattern, i);

                    // Save the frame as BMP using BmpOptions
                    frame.Save(outputPath, new BmpOptions());
                }
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
 * 1. When a legacy industrial system only accepts BMP files, developers can extract each frame of an animated PNG and save them as separate BMP images for compatibility.
 * 2. When creating a frame‑by‑frame video preview for a web application, developers can convert APNG animation frames to BMP to simplify further processing or compositing.
 * 3. When preparing assets for a printing workflow that does not support animated PNG, developers can turn each APNG frame into a BMP to ensure accurate raster output.
 * 4. When performing image analysis or computer‑vision tasks on individual animation frames, developers can export the APNG frames to BMP format for easier pixel‑level manipulation.
 * 5. When archiving animated graphics in a format recognized by older Windows applications, developers can batch‑convert APNG frames to BMP files for long‑term storage.
 */
