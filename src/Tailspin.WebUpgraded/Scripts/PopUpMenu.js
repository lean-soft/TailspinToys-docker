function IEHoverPseudo() {
	var navItems = document.getElementById("ul_NavBar").getElementsByTagName("li");

	for (var i=0; i<navItems.length; i++) {
		navItems[i].onmouseover=function() {
			this.className+=" over";
		}
		navItems[i].onmouseout=function() {
			this.className=this.className.replace(new RegExp(" over\\b"), "");
		}
	}

}
window.onload = IEHoverPseudo;


/*/
sfHover = function() {
	var sfEls = document.getElementById("navmenu").getElementsByTagName("LI");
	
	for (var i=0; i<sfEls.length; i++) {
		sfEls[i].onmouseover=function() {
			this.className+=" sfhover";
		}
		sfEls[i].onmouseout=function() {
			this.className=this.className.replace(new RegExp(" sfhover\\b"), "");
		}
	}
}
if (window.attachEvent) window.attachEvent("onload", sfHover);
*/

/*BACKUP

function IEHoverPseudo() {
	var navItems = document.getElementById("ul_NavBar").getElementsByTagName("li");

	for (var i=0; i<navItems.length; i++) {
		if(navItems[i].className == "menuparent") {
			navItems[i].onmouseover=function() { this.className = "menuparent over"; }
			navItems[i].onmouseout=function() { this.className = "menuparent"; }
		}
	}

}
window.onload = IEHoverPseudo;

*/