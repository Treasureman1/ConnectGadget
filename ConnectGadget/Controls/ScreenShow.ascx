<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScreenShow.ascx.cs" Inherits="ConnectGadget.Controls.ScreenShow" %>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script src="Scripts/jquery.cycle.all.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#slideshow').cycle({
                timeout: 5000,  // milliseconds between slide transitions (0 to disable auto advance)
                fx: 'fade', // choose your transition type, ex: fade, scrollUp, shuffle, etc...            
                pager: '#pager',  // selector for element to use as pager container
                pause: 0,   // true to enable "pause on hover"
                pauseOnPagerHover: 0 // true to pause when hovering over pager link
            });
            $('#featured').cycle({
                timeout: 12000,  // milliseconds between slide transitions (0 to disable auto advance)
                fx: 'scrollUp', // choose your transition type, ex: fade, scrollUp, shuffle, etc...                        
                pause: 0,   // true to enable "pause on hover"
                pauseOnPagerHover: 0 // true to pause when hovering over pager link
            });
        });
    </script>
    <asp:Repeater ID="slideShowRepeater" runat="server">
        <HeaderTemplate>
            <div id="slideshow">
            <!-- start slideshow -->
        </HeaderTemplate>

        <ItemTemplate>
            <!-- Start slide content -->
            <div class="slide-text">
                <a class="thickbox preview_link" href="images/product-audio.jpg">
                    <img src="images/product-audio.jpg" alt="audio products" /></a>
                <h2>
                    <a href="audio.aspx">Audio</a></h2>
                <p>
                    Whether you are interested in full systems or individual components, we offer the
                    best in automotive audio solutions including stereo systems, speakers, subwoofers
                    and amplifiers. We also offer installation services from basic to full custom including
                    custom enclosures, unique layouts, and discreet wiring.</p>
                <div class="view_details">
                    <a href="audio.aspx">
                        <img src="images/view_details.png" style="background: none; border: none" alt="Audio Products" /></a>
                </div>
            </div>
            <!-- end of slide 1 -->
        </ItemTemplate>

        <FooterTemplate>
            </div>
            <!-- end slideshow -->
        </FooterTemplate>
    </asp:Repeater>
        <div class="slide-text">
            <a href='images/product-video.jpg' title="Product" class="group" rel="group">
                <img src="images/product-video.jpg" alt="video products" /></a>
            <h2>
                <a href="video.aspx">Video</a></h2>
            <p>
                We offer a wide variety of automotive video solutions to meet your specific needs
                including flip-out systems, drop-down systems, and double-din systems.
                In addition, our installation services will assure your in-car entertainment experience
                is the best possible.</p>
            <div class="view_details">
                <a href="video.aspx">
                    <img src="images/view_details.png" style="background: none; border: none" alt="Details" /></a>
            </div>
        </div>
        <!-- end of slide 2 -->
        <div class="slide-text">
            <a href='images/product-nav.jpg' title="Product" class="group" rel="group">
                <img src="images/product-nav.jpg" alt="navigation" /></a>
            <h2>
                <a href="navigation.aspx">Navigation</a></h2>
            <p>
                Whether you are in the market for an indendent GPS system or a fully integrated
                solution, our navigation systems will get you to where you want to be. We offer solutions
                that include turn-by-turn directions, traffic congestion rerouting, information on
                nearby amenities (restaurants, gas stations, tourest attractions, etc.), Bluetooth integration
                and more.
            </p>
            <div class="view_details">
                <a href="navigation.aspx">
                    <img src="images/view_details.png" style="background: none; border: none" alt="Details" /></a>
            </div>
        </div>
        <!-- end of slide 3 -->
        <div class="slide-text">
            <a href='images/product-alarm.jpg' title="Product" class="group" rel="group">
                <img src="images/product-alarm.jpg" alt="alarms" /></a>
            <h2>
                <a href="alarms.aspx">Security</a></h2>
            <p>
                You've invested a lot in your vehicle and our security systems will help to protect
                your investment. We offer a wide variety of automotive security solutions that include
                the latest technology for keyless entry, remote start, ranged alarms, engine kill, 
                tactile sensing, vibration detection and remote tracking.
            </p>
            <div class="view_details">
                <a href="alarms.aspx">
                    <img src="images/view_details.png" style="background: none; border: none" alt="Details" /></a>
            </div>
        </div>
        <!-- end of slide 4 -->
Screen show here