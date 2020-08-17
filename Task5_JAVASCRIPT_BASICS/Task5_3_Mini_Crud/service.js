class Service {

    constructor() {
        this.collection = new Map();
        this.count = 0;
    }

    add(objectToAdd) {
        if (typeof(objectToAdd) == 'object') {
            this.collection.set(this.count.toString(), objectToAdd);
            console.log("This object was added"); 
            this.count++;
        }
        else {
            return "This element is not Object";
        }
    }

    getById(objectId) {
        if (objectId != undefined) {
            if (this.collection.has(objectId)){
                return this.collection.get(objectId);
            }
            else {
                return null;
            }
        }
        else {
            return false;
        }
    }

    getAll() {
        return this.collection;
    }

    deleteById(objectId) {
        if (this.collection.has(objectId)) {
            let deletedObject = this.collection.get(objectId);
            this.collection.delete(objectId);
            return deletedObject;
        }
        else {
            return "This object is not in the collection";
        }
    }

    updateById(objectId, objectToAdd) {
        if (this.collection.has(objectId)) {
            if (typeof(objectToAdd) == 'object') {
                for (let key in this.collection.get(objectId)) {
                    this.collection.get(objectId)[key] = objectToAdd[key];
                    return "Successfully updated";
                };
            }
            else {
                return "This element is not object";
            }
        }
        else {
            return "There are no element in this collection";
        }
    }

    replaceById(objectId, objectToReplace) {
        if (this.collection.has(objectId)) {
            if (typeof(objectToReplace) == 'object') {
                this.collection.set(objectId.toString(), objectToReplace);    
                return "Successfully replaced";
            }
            else {
                return "This element is not object";
            }
        }
        else {
            return "There are no element in this collection";
        }
}

}

let testObject = {
    name: "Angelina",
    age: 21,
}

let testObject2 = {
    name: "Cat",
    age: 6,
    superSkill: "jumping",
}
let testObject3 = {
    name: "Ivan",
    age: 15,
}
let storage = new Service();

storage.add(testObject);
storage.add(testObject2);
console.log(storage.getById());
console.log(storage.getAll());
console.log(storage.updateById("0",testObject3));
console.log(storage.replaceById("1",testObject3));
console.log(storage.getAll());
