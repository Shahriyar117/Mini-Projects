function myFunction() {
		// body...
   let text = document.getElementById("inputbox").value;
   let li = document.createElement("li");
   if (document.getElementById("inputbox").value !== "") {
   li.textContent = text;
   li.style="border-bottom:1px solid black; font-size:20px;";
 
   let x = document.createElement("x");
   x.innerHTML = " <i>delete</i>";
   x.style="float :right;color:grey;cursor:pointer";
   x.classList.add("material-icons");
   x.addEventListener("click", function () {
       let li = x.parentNode;
       li.parentNode.removeChild(li);
   });
   li.appendChild(x);
    
    
   let items = document.getElementById("items");
   items.appendChild(li);
    
   document.getElementById("inputbox").value = "";
  
	};
}
