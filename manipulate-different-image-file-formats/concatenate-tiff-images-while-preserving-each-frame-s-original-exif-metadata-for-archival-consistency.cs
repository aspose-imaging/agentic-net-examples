using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.tif",
            @"C:\Images\input2.tif",
            @"C:\Images\input3.tif"
        };
        string outputPath = @"C:\Images\output.tif";

        try
        {
            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first TIFF to initialise the result image
            using (TiffImage firstTiff = Image.Load(inputPaths[0]) as TiffImage)
            {
                if (firstTiff == null)
                {
                    Console.Error.WriteLine($"Failed to load TIFF: {inputPaths[0]}");
                    return;
                }

                // Create a new TiffImage using the first frame of the first source
                using (TiffImage result = new TiffImage(firstTiff.Frames[0]))
                {
                    // Add remaining frames from the first source (if any)
                    for (int i = 1; i < firstTiff.Frames.Length; i++)
                    {
                        result.AddFrame(firstTiff.Frames[i]);
                    }

                    // Process the rest of the input files
                    for (int idx = 1; idx < inputPaths.Length; idx++)
                    {
                        using (TiffImage src = Image.Load(inputPaths[idx]) as TiffImage)
                        {
                            if (src == null)
                            {
                                Console.Error.WriteLine($"Failed to load TIFF: {inputPaths[idx]}");
                                continue;
                            }

                            // Add all frames from the current source TIFF
                            result.Add(src);
                        }
                    }

                    // Save the concatenated multi‑page TIFF
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}