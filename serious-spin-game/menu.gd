extends Control
@onready var panel: Panel = $Panel
@onready var label: Label = $Label
@onready var start: Button = $Start
@onready var close: Button = $Close
@onready var options: Button = $Options
@onready var options_2: Panel = $Options2
@onready var op_label: Label = $Options2/Op_Label


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	panel.visible = true
	label.visible = true
	start.visible = true
	options.visible = true
	close.visible = true
	options_2.visible = false
	


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func _on_start_pressed() -> void:
	print("Start was pressed")
	get_tree().change_scene_to_file("res://src/gameplay/player/player.tscn") #pls change later


func _on_options_pressed() -> void:
	print("Options was pressed")
	panel.visible = false
	label.visible = false
	start.visible = false
	options.visible = false
	close.visible = false
	options_2.visible = true
	


func _on_close_pressed() -> void:
	print("Close was pressed")
	get_tree().quit()


func _on_back_pressed() -> void:
	panel.visible = true
	label.visible = true
	start.visible = true
	options.visible = true
	close.visible = true
	options_2.visible = false
