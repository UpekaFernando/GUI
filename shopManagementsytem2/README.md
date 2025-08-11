# Shop Management System

## Image Loading Guide

This application uses both local image files and web-based fallback images to ensure the UI always looks good. To ensure proper image loading:

### Required Image Files

Make sure these image files are present in your project's root directory:
- `login.jpg` - Used for the main login screen background
- `dashboard.jpg` - Used for the dashboard backgrounds

### Setting Up Images Properly

1. **Add Images to Project**:
   - Right-click on your project in Solution Explorer
   - Select "Add" ? "Existing Item..."
   - Browse to and select `login.jpg` and `dashboard.jpg`
   - Click "Add"

2. **Set Build Action**:
   - Select each image file in Solution Explorer
   - In the Properties window, set:
     - "Build Action" to "Content"
     - "Copy to Output Directory" to "Copy if newer"

3. **Alternative Methods**:
   If the images still don't load properly, try one of these approaches:

   a. **Create an Images Folder**:
   ```
   - Create a folder called "Images" in your project
   - Add your image files to this folder
   - Update the image references in the code to "Images/login.jpg"
   ```

   b. **Use Resource References**:
   ```
   - Set the Build Action for each image to "Resource"
   - Use pack URI references like "pack://application:,,,/login.jpg"
   ```

### Troubleshooting

If images are not displaying:

1. **Check Output Paths**:
   - Look in the "bin/Debug/net8.0" folder to verify images were copied
   - Check the Debug output for any error messages

2. **Check File Permissions**:
   - Make sure the application has read permissions for the image files

3. **Use Web Fallback**:
   - The application will automatically fall back to web-based images if local files are not available
   - Ensure your internet connection is working properly

4. **Database Connectivity**:
   - If you have issues connecting to MySQL, the application will fall back to SQLite
   - Check the database connection strings in MenuDb.cs

## Debugging

To see detailed diagnostic information, run the application in Debug mode and check the Output window for messages about image loading and database connectivity.
