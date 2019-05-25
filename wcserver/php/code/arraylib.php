<?php

function object_2_array($data)
{
	if(is_array($data) || is_object($data))
	{
		$result = array();
		foreach ($data as $key => $value)
		{
			$result[$key] = object_2_array($value);
		}
		return $result;
	}
	return $data;
}


?>
