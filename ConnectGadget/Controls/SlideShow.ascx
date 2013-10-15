<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SlideShow.ascx.cs" Inherits="ConnectGadget.Controls.SlideShow" %>

<script type="text/javascript">
    // Assumes dojo has already been loaded!
    dojo.require("dojox.image.SlideShow");
    dojo.require("dojo.data.ItemFileReadStore");
    dojo.require("dojo.parser"); // find widgets		

    dojo.addOnLoad(function () {
        // See http://archive.dojotoolkit.org/nightly/dojotoolkit/dojox/image/tests/test_SlideShow.html
        dojo.parser.parse();
        dijit.byId('<%=dijitSlideShow1.ClientID %>').setDataStore(imageItemStore,
				{ query: {}, count: 20 },
				{
				    imageThumbAttr: "thumb",
				    imageLargeAttr: "large"
				}
			);
    });
			
</script>

<div data-dojo-id="imageItemStore" dojoType="dojo.data.ItemFileReadStore" url="slideShowImages.json"></div>

<div id="slideshow1" dojoType="dojox.image.SlideShow"></div>
