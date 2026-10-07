// HOW-TO: Alpha Blend Images From ZIP And Write To New ZIP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputZipPath = "input.zip";
        string outputZipPath = "output.zip";

        try
        {
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath) ?? ".");

            using (FileStream outFs = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive outputArchive = new ZipArchive(outFs, ZipArchiveMode.Update))
            using (ZipArchive inputArchive = ZipFile.OpenRead(inputZipPath))
            {
                foreach (var entry in inputArchive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name))
                        continue;

                    using (var entryStream = entry.Open())
                    using (var ms = new MemoryStream())
                    {
                        entryStream.CopyTo(ms);
                        ms.Position = 0;

                        using (RasterImage srcImage = (RasterImage)Image.Load(ms))
                        {
                            string tempCanvasPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                            Source canvasSource = new FileCreateSource(tempCanvasPath, false);
                            PngOptions pngOptions = new PngOptions() { Source = canvasSource };

                            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, srcImage.Width, srcImage.Height))
                            {
                                canvas.Blend(new Point(0, 0), srcImage, 128);
                                canvas.Save();
                            }

                            byte[] data = File.ReadAllBytes(tempCanvasPath);
                            var outEntry = outputArchive.CreateEntry(entry.Name);
                            using (var outEntryStream = outEntry.Open())
                            {
                                outEntryStream.Write(data, 0, data.Length);
                            }

                            File.Delete(tempCanvasPath);
                        }
                    }
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
 * 1. When you need to batch‑process a collection of photos stored in a zip file and apply a semi‑transparent overlay to each image before distributing them.
 * 2. When you want to create watermarked thumbnails from archived graphics by blending them with a custom canvas and repackaging the results.
 * 3. When an application must read scanned documents from a compressed archive, apply a uniform opacity effect, and save the modified files back into another zip for downstream processing.
 * 4. When you are building a server‑side service that receives a zip of user‑uploaded PNGs, applies a 50 % alpha blend to normalize appearance, and returns a new zip with the adjusted images.
 * 5. When you need to automate the preparation of assets for a game engine by loading sprites from a zip, blending them onto a transparent background, and exporting the blended sprites into a new archive.
 */
