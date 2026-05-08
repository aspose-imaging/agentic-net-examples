using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputZipPath = "output.zip";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (FileStream inputFs = new FileStream(inputZipPath, FileMode.Open, FileAccess.Read))
            using (System.IO.Compression.ZipArchive inputArchive = new System.IO.Compression.ZipArchive(inputFs, System.IO.Compression.ZipArchiveMode.Read))
            using (FileStream outputFs = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write))
            using (System.IO.Compression.ZipArchive outputArchive = new System.IO.Compression.ZipArchive(outputFs, System.IO.Compression.ZipArchiveMode.Create))
            {
                foreach (var entry in inputArchive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name))
                        continue; // skip directories

                    using (Stream entryStream = entry.Open())
                    using (Aspose.Imaging.Image loadedImage = Aspose.Imaging.Image.Load(entryStream))
                    {
                        Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)loadedImage;
                        int width = overlay.Width;
                        int height = overlay.Height;

                        // Create a blank canvas with white background
                        StreamSource canvasSource = new StreamSource(new MemoryStream());
                        PngOptions pngOptions = new PngOptions() { Source = canvasSource };
                        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, width, height))
                        {
                            int[] whitePixels = new int[width * height];
                            int whiteArgb = Aspose.Imaging.Color.FromArgb(255, 255, 255, 255).ToArgb();
                            for (int i = 0; i < whitePixels.Length; i++)
                                whitePixels[i] = whiteArgb;

                            canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height), whitePixels);

                            // Blend the overlay image onto the canvas with 50% opacity
                            canvas.Blend(new Aspose.Imaging.Point(0, 0), overlay, 128);

                            // Save blended image to the output zip
                            using (MemoryStream ms = new MemoryStream())
                            {
                                canvas.Save(ms, pngOptions);
                                ms.Position = 0;
                                var outEntry = outputArchive.CreateEntry(entry.FullName);
                                using (Stream outStream = outEntry.Open())
                                {
                                    ms.CopyTo(outStream);
                                }
                            }
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