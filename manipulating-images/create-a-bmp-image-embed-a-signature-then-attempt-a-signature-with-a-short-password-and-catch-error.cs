using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string originalPath = "original.bmp";
            string signedPath = "signed.bmp";
            string shortPwdPath = "shortpwd.bmp";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(signedPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(shortPwdPath) ?? string.Empty);

            // Create a simple 100x100 white BMP image
            using (var image = Image.Create(
                new BmpOptions { BitsPerPixel = 24 },
                100, 100))
            {
                // Fill with white color
                image.Save(originalPath);
            }

            // Verify the image was created
            if (!File.Exists(originalPath))
            {
                Console.Error.WriteLine($"File not found: {originalPath}");
                return;
            }

            // Load the created BMP and embed a digital signature with a valid password
            using (var image = (RasterImage)Image.Load(originalPath))
            {
                string validPassword = "StrongPassword123";
                image.EmbedDigitalSignature(validPassword);
                image.Save(signedPath);
            }

            // Verify the signed image exists
            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            // Attempt to embed a digital signature with a short password and handle the expected exception
            try
            {
                using (var image = (RasterImage)Image.Load(signedPath))
                {
                    string shortPassword = "pwd"; // Intentionally short
                    image.EmbedDigitalSignature(shortPassword);
                    image.Save(shortPwdPath);
                }
            }
            catch (DigitalSignatureException ex)
            {
                // Expected error due to insufficient password length or other signing issue
                Console.Error.WriteLine($"DigitalSignatureException caught: {ex.Message}");
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
 * 1. When a developer needs to generate a simple 100×100 white BMP thumbnail for a document management system and protect its integrity by embedding a digital signature with a strong password.
 * 2. When an application must programmatically create a blank BMP image as a placeholder and later secure it against tampering using Aspose.Imaging’s EmbedDigitalSignature method.
 * 3. When a workflow requires confirming that a BMP file can be signed, saved, and that the signed file exists before moving on to subsequent image‑processing steps.
 * 4. When a developer wants to illustrate proper error handling by attempting to embed a digital signature with a short password and catching the expected CoreException.
 * 5. When building automated tests for image‑processing pipelines that need to verify both successful BMP signature embedding and the correct exception response for invalid password constraints.
 */