<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js">
</script>
    <script>
        $('#FileUpload').click(function () {
        var uploadedFiles = $("#fileInput").get(0);
        var files = uploadedFiles.files;
        var formData = new FormData();

        for (var i = 0; i < files.length; {
            formData.append(files[i].name, files[i]);
        }
        if (files.length <= 0) {
            $('#SucessMessage').hide();
            $('#SelectFile').html("Please Select File");
            $('#SelectFile').show();
        }
        else {
            $.ajax({
                url: '/CreateIncident/FileUpload',
                type: 'Post',
                data: formData,
                contentType: false,
                processData: false,
                success: function (message) {
                    $('#SelectFile').hide();
                    $('#SucessMessage').html("File Uploaded Sucessfully");
                    $('#SucessMessage').show();
                },
                error: function () {
                    $('#SucessMessage').hide();
                    $('#SelectFile').hide();
                    $('#ErrorMessage').html("Error while uploading files");
                    $('#ErrorMessage').show();
                }
            })
</script>
