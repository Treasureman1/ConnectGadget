<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dojo1.aspx.cs" Inherits="ConnectGadget.Dojo1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 id="greeting">Hello</h1>
    <form id="form1" runat="server">
        <div>
    
        </div>
    </form>
    <ul id="list1">
    </ul>
    <script type="text/javascript" src="/Scripts/dojo-release-1.9.1/dojo/dojo.js" data-dojo-config="async: true"></script>
    <script>
        require(["dojo/dom", "dojo/_base/array", "dojo/dom-construct", "dojo/domReady!"], function (dom, arrayUtil, domConstruct) {
            debugger;
            var arr = ["one", "two", "three", "four"],
            // dom is from dojo/dom
            list1 = dom.byId("list1");
            // Skip over index 4, leaving it undefined
            arr[5] = "six";

            arrayUtil.forEach(arr, function (item, index) {
                // This function is called for every item in the array
                if (index == 3) {
                    // this changes the original array,
                    // which changes the item passed to
                    // the sixth invocation of this function
                    arr[5] = "seven";
                }

                // domConstruct is available at dojo/dom-construct
                domConstruct.create("li", {
                    innerHTML: item + " (" + index + ")"
                }, list1);
            });
        });
        // Require the module we just created
        require(["custom/base"], function (myModule) {
            // Use our module to change the text in the greeting
            myModule.setText("greeting", "Hello Dojo!");

            // After a few seconds, restore the text to its original state
            setTimeout(function () {
                myModule.restoreText("greeting");
            }, 3000);
        });

        require(["dojo/dom", "dojo/fx", "dojo/domReady!"], function (dom, fx) {
            // The piece we had before...
            var greeting = dom.byId("greeting");
            greeting.innerHTML += " from Dojo!";

            // ...but now, with an animation!
            fx.slideTo({
                top: 100,
                left: 200,
                node: greeting
            }).play();
        });

        require(["dojo/request"], function (request) {
            request("ajaxtest.txt").then(
                function (text) {
                    console.log("The file's content is: " + text);
                },
                function (error) {
                    console.log("An error occurred: " + error);
                }
            );
        });
    </script>
</body>
</html>
