using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string[] inputPaths = new[]
            {
                "Input\\image1.jpg",
                "Input\\image2.jpg",
                "Input\\image3.jpg"
            };
            string tempFolder = "Temp";
            string finalFolder = "Output";
            string tempOutputPath = Path.Combine(tempFolder, "merged_temp.jpg");
            string finalOutputPath = Path.Combine(finalFolder, "merged.jpg");

            // Verify input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight) canvasHeight = sz.Height;
            }

            // Prepare JPEG options with temporary file source
            Source tempSource = new FileCreateSource(tempOutputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = tempSource,
                Quality = 90
            };

            // Create canvas and merge images horizontally
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the bound image (file already bound via Source)
                canvas.Save();
            }

            // Verify temporary file was created and move to final destination
            if (File.Exists(tempOutputPath))
            {
                // Overwrite if final file already exists
                if (File.Exists(finalOutputPath))
                {
                    File.Delete(finalOutputPath);
                }
                File.Move(tempOutputPath, finalOutputPath);
                Console.WriteLine($"Merged image saved to: {finalOutputPath}");
            }
            else
            {
                Console.Error.WriteLine("Failed to create the merged image.");
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
 * 1. When a web service needs to combine multiple user‑uploaded JPEG photos into a single panoramic image, it can first write the merged file to a temporary folder, verify its integrity, and then move it to the final output directory.
 * 2. When an automated batch job processes scanned documents, merges them side‑by‑side as a JPEG, and must ensure the merged file is successfully created before publishing it to a document management system, using a temp folder prevents incomplete files from being exposed.
 * 3. When a desktop application creates a composite product thumbnail from several JPEG assets and wants to avoid displaying a partially rendered image, it can generate the thumbnail in a Temp directory, run a checksum verification, and then relocate it to the user‑visible Output folder.
 * 4. When a CI/CD pipeline builds marketing assets by stitching together campaign JPEG images, storing the intermediate merged image in a temporary location allows the pipeline to roll back if the verification step fails before committing the final image to the release folder.
 * 5. When a cloud‑based image processing API merges client‑provided JPEGs horizontally and must guarantee that only fully verified images are stored in the persistent storage bucket, it can write the result to a temporary path, perform validation, and then move the file to the final destination.
 */