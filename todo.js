//todo list 
const todoList = [];
//Todo Class 
class Todo{
    //Contructor for Todo Class
    constructor(item){
        this.ulElement =item;
    } 

    //Fuction for Adding the item in Todo list
    addElement() {
        const todoInput = document.querySelector("#myInput").value;

        //Check If input is not empty,then form the object which store ID and Text 
        if (todoInput == " ") {
            alert("Please enter the todo!!") 
        } else {
            const todo = {
                todoId: todoList.length,
                todoText: todoInput
            };

        //Push the code at the end of the list
        todoList.push(todo);
        this.display();
        document.querySelector("#myInput").value = '';

        }
    }

    //Function for delete the item from Todo list
    deleteElement(itemId) {
        const delIndex = todoList.findIndex((item)=> item.todoId == itemId);
        //splice function start from delIndex and delete 1 item.
        todoList.splice(delIndex, 1);

        this.display();
    }

    //Function for Display the Todo list
    display() {
        //Clear the previous ul elements 
        this.ulElement.innerHTML = "";
        
        todoList.forEach((item) => {

            const liElement = document.createElement("li");
            const delBtn = document.createElement("i");

        //Adding the id of todo in liElement
            liElement.innerText = item.todoText;
            liElement.setAttribute("data-id",item.todoId);

        //Adding the trash icon in delBtn
            delBtn.setAttribute("data-id", item.todoId);
            delBtn.classList.add("far", "fa-trash-alt");

        //Append the delBtn to liElement
            liElement.appendChild(delBtn);

        //Click the delBtn to remove the todo   
            delBtn.addEventListener("click", function(e) {
                const deleteId = e.target.getAttribute("data-id");
                myTodoList.deleteElement(deleteId);
            })
        //Append the new list element in the in the unorder list 
            this.ulElement.appendChild(liElement);
        })
    }
} 


////----------------MAIN---------------------------
const listSection = document.querySelector("#Items");
myTodoList = new Todo(listSection);

document.querySelector(".addBtn").addEventListener("click", function() {
    myTodoList.addElement();
})
