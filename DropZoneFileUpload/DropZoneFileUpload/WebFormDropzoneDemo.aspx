<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDropzoneDemo.aspx.cs" Inherits="DropZoneFileUpload.WebFormDropzoneDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Scripts/dropzone/css/basic.css" rel="stylesheet" />
    <link href="Scripts/dropzone/css/dropzone.css" rel="stylesheet" />
    <style type="text/css">
    .dz-max-files-reached {
        background-color: red;
    }

  

</style>
    <script src="Scripts/dropzone/dropzone.min.js"></script>
    <script type="text/javascript">

        //File Upload response from the server
        Dropzone.options.dropzoneForm = {
            maxFiles: 2,
            url: "WebFormDropzoneDemo.aspx",

            init: function () {
                this.on("maxfilesexceeded", function (data) {
                    var res = eval('(' + data.xhr.responseText + ')');

                });
                this.on("addedfile", function (file) {

                    // Create the remove button
                    var removeButton = Dropzone.createElement("<button>Remove file</button>");


                    // Capture the Dropzone instance as closure.
                    var _this = this;

                    // Listen to the click event
                    removeButton.addEventListener("click", function (e) {
                        // Make sure the button click doesn't submit the form:
                        e.preventDefault();
                        e.stopPropagation();
                        // Remove the file preview.
                        _this.removeFile(file);
                        // If you want to the delete the file on the server as well,
                        // you can do the AJAX request here.
                    });

                    // Add the button to the file preview element.
                    file.previewElement.appendChild(removeButton);
                });
            }
        };


   

   

    </script>
</head>
<body>
    <div class="jumbotron">
    <div  class="dropzone" id="dropzoneForm">
        <div class="fallback">
            <input name="file" type="file" multiple />
            <input type="submit" value="Upload" />
        </div>
    </div>
</div>

</body>
</html>
