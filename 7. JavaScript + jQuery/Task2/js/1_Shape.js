class Shape {
    GetArea() {
        throw new Error("Shape is abstract class");
    }
}

class Square extends Shape {
    constructor(side) {
        super();
        this.size = side;
    }

    GetArea() {
        return this.size * this.size;
    }
}

class Circle extends Shape{
    constructor(radius) {
        super();
        this.radius = radius;
    }

    GetArea() {
        return this.radius * this.radius * Math.PI;
    }
}