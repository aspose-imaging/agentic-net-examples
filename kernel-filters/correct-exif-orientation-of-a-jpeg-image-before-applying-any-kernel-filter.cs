// HOW-TO: Correct JPEG EXIF Orientation Before Applying Filters in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    ushort orientation = (ushort)exif.Orientation;
                    switch (orientation)
                    {
                        case 2:
                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            break;
                        case 3:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 4:
                            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            break;
                        case 5:
                            image.RotateFlip(RotateFlipType.Rotate90FlipX);
                            break;
                        case 6:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 7:
                            image.RotateFlip(RotateFlipType.Rotate270FlipX);
                            break;
                        case 8:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                }

                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When uploading user‑taken photos to a web service, you need to normalize the JPEG EXIF orientation so that subsequent image filters render correctly.
 * 2. When generating thumbnails for a gallery, correcting the JPEG orientation ensures the thumbnail matches the intended view before applying sharpening or blur kernels.
 * 3. When preprocessing images for a machine‑learning pipeline, fixing EXIF rotation guarantees consistent input orientation prior to convolutional filter operations.
 * 4. When creating printable PDFs from JPEGs, adjusting the EXIF orientation prevents rotated pages after applying color‑correction filters.
 * 5. When building a photo‑editing app that applies custom kernel effects, you must first rotate or flip the JPEG based on its EXIF tag to avoid distorted results.
 */
