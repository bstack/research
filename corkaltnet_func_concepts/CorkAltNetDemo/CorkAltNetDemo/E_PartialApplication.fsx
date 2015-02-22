

let shift (dx, dy)(px, py) = (px + dx, py + dy)

let shiftRight = shift(1, 0)
let shiftUp = shift(0, 1)
let shiftLeft = shift(-1, 0)
let shiftDown = shift(0, -1)

shiftRight(10,10);;

List.map(shift(2,2)) [(0,0);(1,0);(1,1);(0,1)];;

