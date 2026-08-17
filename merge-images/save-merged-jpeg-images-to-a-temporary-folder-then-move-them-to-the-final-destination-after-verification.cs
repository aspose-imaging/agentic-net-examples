// HOW-TO: Merge Multiple JPEGs to One File Using Temp Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input JPEG file paths
            string[] inputPaths = {
                @"C:\Images\img1.jpg",
                @"C:\Images\img2.jpg"
            };

            // Hard‑coded final output path
            string finalOutputPath = @"C:\Output\merged.jpg";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load each JPEG image
            Image[] images = new Image[inputPaths.Length];
            for (int i = 0; i < inputPaths.Length; i++)
            {
                images[i] = Image.Load(inputPaths[i]);
            }

            // Create a multipage image from the loaded images
            using (Image merged = Image.Create(images))
            {
                // Prepare temporary folder and file
                string tempFolder = Path.Combine(Path.GetTempPath(), "AsposeMergeTemp");
                Directory.CreateDirectory(tempFolder); // unconditional per requirements
                string tempPath = Path.Combine(tempFolder, "merged_temp.jpg");

                // Save the merged image to the temporary location
                merged.Save(tempPath, new JpegOptions());

                // Verify the temporary file was created
                if (!File.Exists(tempPath))
                {
                    Console.Error.WriteLine($"Failed to create temporary file: {tempPath}");
                    return;
                }

                // Ensure the final output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

                // If a file already exists at the final location, delete it
                if (File.Exists(finalOutputPath))
                {
                    File.Delete(finalOutputPath);
                }

                // Move the verified temporary file to the final destination
                File.Move(tempPath, finalOutputPath);
            }

            // Dispose loaded source images
            foreach (var img in images)
            {
                img.Dispose();
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
 * 1. When you need to combine several JPEG photos into a single image while ensuring the output is only saved after confirming the temporary file was created correctly.
 * 2. When a batch process must verify each source JPEG exists before merging to avoid runtime errors in a C# application.
 * 3. When you want to write the merged JPEG to a secure location only after successful creation in a temporary directory, reducing the risk of corrupted files.
 * 4. When an automated workflow requires creating a combined JPEG and moving it to a final output folder that may not yet exist.
 * 5. When you must isolate the merge operation in a sandboxed temp folder to comply with file‑system permissions or cleanup policies before publishing the result.
 */
