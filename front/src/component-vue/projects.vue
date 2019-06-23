<template>
	<div>
		<section v-for="item in info">
			<article>
				<router-link :to="{ path: '/project/' + item.Id}">{{item.Name}}</router-link>
			</article>
		</section>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'projects',
		data() {
			return {
				info: null
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/projects/')
				.then(response => (this.info = response.data));
		}
	};
</script>
